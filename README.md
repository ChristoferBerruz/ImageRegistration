# ImageRegistration
Windows application to illustrate how image registration works given a known set of correspondence points. I added some noise to illustrate how this affects the transformation found by setting the cost function to zero and solving for it.

The important files here are RegistrationTools.cs and Transformation.cs (for the sake of understanding the mapping).

## Outlier Removal
Current version support outlier removal using the RANSAC algorithm. User input is managed through a Windows Form.

I also added Single Cost and Overall Cost functions to determine the cost of the current model (Transformation).
