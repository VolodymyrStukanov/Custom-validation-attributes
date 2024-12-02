Custom validation attribute

The key folder of project is the "WebApplication1\WebApplication1\Validation" folder.
There are a few components in the folder:
1) The interface for the validation attributes("Validation\Interfaces");
2) The models for returning validation result("Validation\Models");
3) The property attributes which partially repeat the functionality of the attributes from the System.ComponentModel.DataAnnotations namespace("Validation\PropertyAttributes");
4) The ValidationAttribute which contains the functionality for checking used property attributes and forming a response("Validation\ValidationAttributes").

To set up validation using this attributes you have to perform two actions:
1) Prescribe necessary attributes above properties of your model as in "WebApplication1\WebApplication1\Models\MyModel.cs" file;
2) Prescribe the ValidationAttribute above methods you want to validate before it runs as in "WebApplication1\WebApplication1\Controllers\HomeController.cs" file.

The ValidationAttribute allow you to add your custom validation as needed and not write 
"if(modelState.isValid() {...}
else {...})"
in every method.
