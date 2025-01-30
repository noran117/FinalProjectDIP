# Image Mainpulation Program 

## Table of Contents
- [Description](#Description)
- [Features](#Features)
- [Usage](#Usage)
- [Dependencies](#Dependencies)

## Description
This project is a GUI-based image processing application developed in C# using the EmguCV library. It enables users to explore images from their computer and apply various editing, enhancement, and analysis techniques through an intuitive and user-friendly interface. The processed image is displayed in real-time for easy visualization. 
https://github.com/user-attachments/assets/43e8f545-22c0-47cc-8a0f-c634f26fe68a

## Features

 ### 1. Image Details
   - Displays essential image information, including
      - width
      - height
      - format (JPEG, PNG, etc.).  
   - Provides *histograms* for grayscale and RGB channels.  
   - Extracts *image metadata* for detailed properties.
     
 ### 2. Image Resizing:
   - Allows users to resize images while *maintaining aspect ratio* to preserve quality.  

 ### 3. Image Cropping:
   - Users can select and extract a *specific part* of the image.
     
 ### 4. Rotate Images:
   - Rotate images from *-360° to 360°* in *90-degree* steps.
     - Positive angles rotate clockwise.
     - Negative angles rotate counterclockwise.

 ### 5. Brightness and Contrast Adjustment:
   - Users can modify *brightness and contrast* using adjustable controls for better visual enhancement.  

 ### 6. Color Tinting:
   - Enables users to apply *custom color tints* with adjustable transparency for a unique effect.  

### 7. Add Text
   - Allows overlaying *custom text* onto the image.  

### 8. Add Logos:
   - Inserts a *logo* at a specified corner of the image.  

### 9. Watermarking:
   - Adds a watermark (either *text or an image*) to protect content.  

### 10. Undo Feature:
   - Supports up to *three undo steps* for better editing control.

### 11. Intensity Transformations:
   - *Histogram Equalization* 
   - *Gamma Correction*  
   - *Log Transformation*  

### 12. Image Analysis:
   - Displays *edge maps* using different *high-pass filters* to highlight details.  

### 13. Filters & Effects:
   - *Smoothing (Box & Gaussian filters)* to reduce noise.  
   - *Sharpening* to enhance details.  
   - *Color Mapping:*
      - *Cold Filter* for a cool-toned effect.
      - *Warm Filter* for a warmer look.

### 14. Image Conversion:
   - Converts images between different *color spaces* (e.g., LAB, grayscale, and HSV).

### 15. Save Processed Image:
   - Saves the final edited image in various formats for later use.

This project provides a *powerful yet easy-to-use tool* for image processing, offering essential editing and enhancement features with a *simple and intuitive interface*.

 ## Usage
 
  Load an image into the application, choose the desired operation from the menu, and apply modifications. Save the edited image as needed.


## Dependencies

   -  C# (.NET Framework/.NET Core) – Required for running the application
   -  Emgu CV – For image processing and computer vision operations
   -  Windows Forms (WinForms) – For the graphical user interface
   -  System.Drawing – For handling image rendering and modifications

 ## Contributions
 
  Contributions and improvements to this C#-based Image Processing Application are welcome. Feel free to fork the repository, make enhancements, and submit a pull request.


 
  Enjoy using the C#-based Image Processing Application! Feel free to contribute to its development and help enhance its features and functionality.
 
