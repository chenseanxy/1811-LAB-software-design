#%% [markdown]
# # Simple CNN for MNIST
#%% [markdown]
# ## Imports:  
# 

#%%
import pandas as pd
import numpy as np
import matplotlib.pyplot as plt
import matplotlib.image as mpimg
import seaborn as sns
%matplotlib inline

np.random.seed(2)

from sklearn.model_selection import train_test_split
from sklearn.metrics import confusion_matrix
import itertools

from keras.utils.np_utils import to_categorical # convert to one-hot-encoding
from keras.models import Sequential
from keras.layers import Dense, Dropout, Flatten, Conv2D, MaxPool2D
from keras.optimizers import RMSprop
from keras.preprocessing.image import ImageDataGenerator
from keras.callbacks import ReduceLROnPlateau, TensorBoard

import tensorflow as tf
import os
import time
import pickle

sns.set(style='white', context='notebook', palette='deep')

#%% [markdown]
# #### Working directory:

#%%
working_dir="C:/Users/chenx/Desktop/1811_softdesign/20181125 - MNIST/"

#%% [markdown]
# ## Data

#%%
train_csv_path = os.path.join(working_dir, "train.csv")
test_csv_path = os.path.join(working_dir, "test.csv")

train = pd.read_csv(train_csv_path)
test = pd.read_csv(test_csv_path)

#%% [markdown]
# #### Separate training data into X,Y:  
# X: Training Label  
# Y: Image Data

#%%
Y_train = train["label"]
X_train = train.drop(labels = ["label"],axis = 1) 

# Visualization:
g = sns.countplot(Y_train)
Y_train.value_counts()

#%% [markdown]
# #### Checking for nulls:

#%%
X_train.isnull().any().describe()


#%%
test.isnull().any().describe()

#%% [markdown]
# #### Normalization:
#   
#   From grayscale 0~255 to 0~1  
#   

#%%
X_train = X_train / 255.0
test = test / 255.0

#%% [markdown]
# #### Reshaping:
# From 1D 784 to 28x28x1

#%%
X_train = X_train.values.reshape(-1,28,28,1)
test = test.values.reshape(-1,28,28,1)

g = plt.imshow(X_train[0][:,:,0], cmap=plt.cm.binary)

#%% [markdown]
# #### Y_train label to hot vector

#%%
Y_train = to_categorical(Y_train, num_classes = 10)

Y_train[0]

#%% [markdown]
# #### Splitting test data

#%%
random_seed = 0

X_train, X_test, Y_train, Y_test = train_test_split(X_train, Y_train,
                                                  test_size=0.1, # 10% used for validation
                                                  random_state=random_seed)

#%% [markdown]
# #### Saving processed data
#     Using pickle to save processed data

#%%
pfile = open(os.path.join("X_train.pickle"), "wb")
pickle.dump(X_train, pfile)
pfile.close()

pfile = open(os.path.join("X_test.pickle"), "wb")
pickle.dump(X_test, pfile)
pfile.close()

pfile = open(os.path.join("Y_train.pickle"), "wb")
pickle.dump(Y_train, pfile)
pfile.close()

pfile = open(os.path.join("Y_test.pickle"), "wb")
pickle.dump(Y_test, pfile)
pfile.close()

#%%
# Loading pickle data
pfile = open(os.path.join("X_train.pickle"), "rb")
X_train = pickle.load(pfile)
pfile.close()

pfile = open(os.path.join("X_test.pickle"), "rb")
X_test = pickle.load(pfile)
pfile.close()

pfile = open(os.path.join("Y_train.pickle"), "rb")
Y_train = pickle.load(pfile)
pfile.close()

pfile = open(os.path.join("Y_test.pickle"), "rb")
Y_test = pickle.load(pfile)
pfile.close()

#%% [markdown]
# ## Models
# + Simple
# + Convoluted
#%% [markdown]
# ### Super simple model
#      Input Layer
#      All connected, size 128
#      All connected, size 128
#      Output all connected, size 10

#%%
simple_model = Sequential()

simple_model.add(Flatten())
simple_model.add(Dense(128, activation="relu"))
simple_model.add(Dense(128, activation="relu"))
simple_model.add(Dense(10, activation="softmax"))

#%% [markdown]
# #### Training
#     Using "adam" as optimizer: this is an ordinary optimizer for NNs
#     "categorical_crossentropy" as loss function: this is also ordinary
#     Epoch: 5, not a very complicated network

#%%
simple_model.compile(optimizer='adam',
            loss='categorical_crossentropy',
            metrics=['accuracy'])


#%%
simple_model.fit(X_train, Y_train, epochs=5)

#%% [markdown]
# #### Evaluation
#      Loss and accuracy is slightly lower than in training:
#      Not very overfitted

#%%
val_loss, val_acc = simple_model.evaluate(X_test, Y_test)
print(val_loss, val_acc)

#%% [markdown]
# #### Looking at a random example

#%%
predictions = simple_model.predict([X_test])


#%%
choice = np.random.randint(0,4201)

print(np.argmax(predictions[choice]))
g = plt.imshow(X_test[choice][:,:,0], cmap=plt.cm.binary)

#%% [markdown]
# #### Saving simple_model

#%%
simple_model_name = "mnist-simple-{}.model".format(int(time.time()))
simple_model.save(os.path.join(simple_model_name))

#%% [markdown]
# ### CNN Model:
#     Convlution size32 x2
#     Down Sampling by 2x2
#     Drop Out by 25% probablity
#     
#     Convlution size64 x2
#     Down Sampling by 2x2
#     Drop Out by 25% probablity
#     
#     Flatten layer
#     All connected size256
#     Drop Out by 50% probablity
#     Output all connected size10

#%%
cnn_model = Sequential()

cnn_model.add(Conv2D(filters = 32,
                    kernel_size = (5,5),
                    padding = 'Same',
                    activation = 'relu'))

cnn_model.add(Conv2D(filters = 32,
                    kernel_size = (5,5),
                    padding = 'Same',
                    activation = 'relu'))

cnn_model.add(MaxPool2D(pool_size=(2, 2)))
cnn_model.add(Dropout(0.25))


cnn_model.add(Conv2D(filters = 64,
                    kernel_size = (3, 3),
                    padding = 'Same',
                    activation = 'relu'))

cnn_model.add(Conv2D(filters = 64,
                    kernel_size = (3, 3),
                    padding = 'Same',
                    activation = 'relu'))

cnn_model.add(MaxPool2D(pool_size=(2, 2),
                        strides=(2, 2)))
cnn_model.add(Dropout(0.25))

cnn_model.add(Flatten())
cnn_model.add(Dense(256, activation='relu'))
cnn_model.add(Dropout(0.5))
# Output Layer
cnn_model.add(Dense(10, activation='softmax'))

#%% [markdown]
# #### Optimizer and loss function
# * Optimizer:
#     RMSprop
# * Loss Function:
#     categorical_crossentropy as ordinary loss function

#%%
cnn_model.compile(optimizer=RMSprop(lr=0.001, rho=0.9, epsilon=1e-08, decay=0.0),
                loss='categorical_crossentropy',
                metrics=['accuracy'])

#%% [markdown]
# #### Learning rate reduction

#%%
learning_rate_reduction = ReduceLROnPlateau(monitor='val_acc', 
                                            patience=3, 
                                            verbose=1, 
                                            factor=0.5, 
                                            min_lr=0.00001)

#%% [markdown]
# #### Data augmentation
#     Randomly shift, zoom ,rotate; manipulate the images to minimize overfitting

#%%
datagen = ImageDataGenerator(
        featurewise_center=False,  # set input mean to 0 over the dataset
        samplewise_center=False,  # set each sample mean to 0
        featurewise_std_normalization=False,  # divide inputs by std of the dataset
        samplewise_std_normalization=False,  # divide each input by its std
        zca_whitening=False,  # apply ZCA whitening
        rotation_range=10,  # randomly rotate images in the range (degrees, 0 to 180)
        zoom_range = 0.1, # Randomly zoom image 
        width_shift_range=0.1,  # randomly shift images horizontally (fraction of total width)
        height_shift_range=0.1,  # randomly shift images vertically (fraction of total height)
        horizontal_flip=False,  # randomly flip images
        vertical_flip=False)  # randomly flip images

datagen.fit(X_train)

#%%
cnn_model_name = "mnist-cnn-{}".format(int(time.time()))
logd = os.path.join(working_dir, "logs", cnn_model_name)
tensorboard = TensorBoard(log_dir=logd)

#%%
epochs = 30
batch_size = 100
history = cnn_model.fit_generator(datagen.flow(X_train,Y_train,batch_size=batch_size),
                                  epochs = epochs, 
                                  validation_data = (X_test,Y_test),
                                  verbose = 2, 
                                  steps_per_epoch = X_train.shape[0] // batch_size, 
                                  callbacks = [learning_rate_reduction])