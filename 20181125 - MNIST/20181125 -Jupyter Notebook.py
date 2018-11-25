#%% [markdown]
# # Task 1
#%% [markdown]
# Input: string from input()

#%%
raw=input()
rad=float(raw)
area=3.14159*rad**2
print(area)

#%% [markdown]
# # Task 2
#%% [markdown]
# Currently not available due to Jupyter restrictions
#%% [markdown]
# # Task 3
#%% [markdown]
# Using python's eval() function for evalutaion

#%%
input3=input()
result=eval(input3)
print(input3, result, sep="=")

#%% [markdown]
# # Task 4
#%% [markdown]
# Generates random student data for stuCount students, into stuData list

#%%
import random
stuCount=100
stuData=[]
for i in range(stuCount):
    stuData.append(random.randrange(0,100))

#%% [markdown]
# Visualizes stuData:  
# Range 1: 90+  
# Range 2: 80-89  
# Range 3: 70-70  
# Range 4: 60-69  
# Range 5: 59-  

#%%
counts=[0,0,0,0,0]
visStrings=("90 -100:", "80 - 89:", "70 - 79:", "60 - 69:", "0  - 59:")

for score in stuData:
    if(score > 89):
        counts[0]+=1
    elif(score > 79):
        counts[1]+=1
    elif(score > 69):
        counts[2]+=1
    elif(score > 59):
        counts[3]+=1
    else:
        counts[4]+=1

for i in range(5):
    line=visStrings[i]+"*"*counts[i]
    print(line)

#%% [markdown]
# # Task 5
#%% [markdown]
# Currently not available due to Jupyter restrictions

