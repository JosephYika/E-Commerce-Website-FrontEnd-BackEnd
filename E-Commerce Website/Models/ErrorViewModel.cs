using System;

/* Model is responsible for managing the data of the application.
   It contains no busines logic. Models are the entity representation of the 
   database tables that consists of the properties of table columns.
   
   Model is stored in a table format. However we define the model , that is how  
   the data will be stored in a database

   View - it is the user interface. It contains the markup. It uses the Razor 
   engine to render the view. View renders the model data passsed to it via any controller.
   View also contains c sharp code.

   Controller - handles the user interaction, and it is responsible for 
   invoking the action based on the route and fecthing data from the model to 
   render on the view. 

   Controller handles the communication with the server. It gets the model, so it knows 
   how to handle the data and then sends it to the view, so the view knows what to display , and this 
   is send to the browser

   So what is MVC - MVC is a workflow and design pattern for developing applications.

   The controller receives the HTTPS requests, then it interacts with the model to handle the data, and then 
   it sends it to the view, then the view knows what to display and sends it back to controller which sends it to the browser.

   The workflow of MVC architecture:

   Browser sends the request to the server, then the server finds the route specified by the browser URL and sends it via
   route to the controller. The request goes to the specific controller based on the route name (e.g Home/Index). The controller now 
   communicates with the model to fetch the data, the model sends the data, then the controller sends the data to 
   the specific view assigned to the action ( from the URL e.g. Index). View now populates the model data. Then finally , when the controller has everything it needs, 
   it sends the response to the server and the server to the browser. 
   
 
    Model represents the shape of the data. 
    Each property of the model represent the column in a database 
    so if we have got 3 properties .e.g. -id, name, lastname, there will be three columns 
    It maintains the data of the application
    Model classes rside in the model folder in mvc architecture

    This ErrorViewModel class is not the model data - we need to create a separate class inside the model folder
    I just wrote my notes here , because there was a lot of space
 
 */

namespace E_Commerce_Website.Models
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
