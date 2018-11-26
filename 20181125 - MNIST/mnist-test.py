#%%
import numpy as np
import matplotlib.pyplot as plt
import os
import cv2
get_ipython().run_line_magic('matplotlib', 'inline')

#%%
DATASET='C:/Users/chenx/Desktop/1811_softdesign/20181125 - MNIST/dataset/noaa'
CAT=(0,1,2,3,4,5,6,7,8,9)


#%%
predictData=[]
img=[]
for num in CAT:
    img_pth=os.path.join(DATASET, str(num)+'.jpg')
    img_array=cv2.imread(img_pth, cv2.IMREAD_GRAYSCALE)
    img_array=255-img_array
    img_array=img_array/255.0
    img.append(img_array)
    new_array=cv2.resize(img_array, (28, 28))
    new_array = new_array.reshape(-1, 28, 28, 1)
    predictData.append(new_array)

#%%
import tensorflow as tf
from keras.models import load_model
model=load_model('C:\\Users\\chenx\\Desktop\\1811_softdesign\\20181125 - MNIST\\models\\mnist-cnn-e16-b64-1543153226.model')
    
#%%
new_array
#%%
for i in range(10):
    predictions=model.predict([predictData[i]])
    print(np.argmax(predictions))

    plt.imshow(img[i], cmap='gray')
    plt.show()