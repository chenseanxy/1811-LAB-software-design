#%% [markdown]
# # Simple CNN for MNIST
#%% [markdown]
# ### Imports:  
# 

#%%
import pandas as pd
import numpy as np
import matplotlib.pyplot as plt
import matplotlib.image as mpimg
import seaborn as sns
get_ipython().run_line_magic('matplotlib', 'inline')

np.random.seed(2)

from sklearn.model_selection import train_test_split
from sklearn.metrics import confusion_matrix
import itertools

from keras.utils.np_utils import to_categorical # convert to one-hot-encoding
from keras.models import Sequential
from keras.layers import Dense, Dropout, Flatten, Conv2D, MaxPool2D
from keras.optimizers import RMSprop
from keras.preprocessing.image import ImageDataGenerator
from keras.callbacks import ReduceLROnPlateau

sns.set(style='white', context='notebook', palette='deep')

#%% [markdown]
# ### Data

#%%
train = pd.read_csv("C:/Users/chenx/Desktop/1811_softdesign/20181125 - MNIST/train.csv")
test = pd.read_csv("C:/Users/chenx/Desktop/1811_softdesign/20181125 - MNIST/test.csv")

#%% [markdown]
# #### Separate training data into X,Y:  
# Y: Training Label  
# X: Image Data

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
# From grayscale 0~255 to 0~1

#%%
X_train = X_train / 255.0
test = test / 255.0

#%% [markdown]
# #### Reshaping:
# From 784 to 28x28x1

#%%
X_train = X_train.values.reshape(-1,28,28,1)
test = test.values.reshape(-1,28,28,1)

g = plt.imshow(X_train[0][:,:,0], cmap=plt.cm.binary)

#%% [markdown]
# #### Y_train label to vector

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
# ### Models
# Simple
# Convoluted

#%% [markdown]
# #### Super simple model as follows:

#%%
simple_model = Sequential()

simple_model.add(Flatten())
simple_model.add(Dense(128, activation="relu"))
simple_model.add(Dense(128, activation="relu"))
simple_model.add(Dense(10, activation="softmax"))


#%%
simple_model.compile(optimizer='adam',
            loss='categorical_crossentropy',
            metrics=['accuracy'])

#%%
simple_model.fit(X_train, Y_train, epochs=3)

#%% [markdown]
# #### Training and evaluation

#%%
val_loss, val_acc = simple_model.evaluate(X_test, Y_test)
print(val_loss, val_acc)

predictions = simple_model.predict([X_test])

#%% [markdown]
# Taking look at a few examples:

#%%
choice = np.random.randint(0,4201)

print(np.argmax(predictions[choice]))
g = plt.imshow(X_test[choice][:,:,0], cmap=plt.cm.binary)

#%% [markdown]
# #### Saving simple model:

#%%
simple_model.save("C:/Users/chenx/Desktop/1811_softdesign/20181125 - MNIST/simple.model")

#%% [markdown]
