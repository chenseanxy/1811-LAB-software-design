#%%
import os
import pandas as pd
import shutil

working_dir = "C:/Users/chenx/Desktop/1811_softdesign/20181216 - Python File"
png_path = os.path.join(working_dir, "train")
csv_path = os.path.join(working_dir, "train_label.csv")

#%%
csv = pd.read_csv(csv_path)
for index, row in csv.iterrows():
    png_filename_1 = str(row["id"])+"_c.png"
    png_filename_2 = str(row["id"])+"_v.png"

    orig_pth_1 = os.path.join(png_path, png_filename_1)
    orig_pth_2 = os.path.join(png_path, png_filename_2)
    
    dest_pth = os.path.join(png_path, str(row["appliance"]))

    if not os.path.isdir(dest_pth):
        os.makedirs(dest_pth)
    
    shutil.copy(orig_pth_1, dest_pth)
    shutil.copy(orig_pth_2, dest_pth)
