# AuthenticationBase

This is a simple MVC app to demonstrate authentication. It can be used as a base
to build other apps on top of, but you should perform your own due diligence to
ensure it meets your security standards.

The important bits live in the following files, which can be copied into your
own project:
 * Models/Authentication/*.cs - the database model, view models, and ASP.NET
   authentication objects
 * Controllers/UserController.cs - the entirety of the business logic
 * Views/User/*.cshtml - the views that correspond to the actions in
   `UserController` for registration, log in, and profile
 * AuthenticationContext.cs - a SIMPLE Entity Framework `DbContext` class; if
   you would like to use one of your own creation, update the two references in
   `UserController` to match your own and ensure it has a `DbSet<Account>`
   property.
 * AuthenticationFilters/*.cs - the authentication filters that you can use to
   decorate your own controller methods.

## Usage

`[AuthenticationPermitted]` checks the internal authentication mechanism provided
by this code and sets the current principal/identity accordingly.

`[AuthenticationRequired]` takes this a step further and redirects you to the
login page if you are not authenticated.

See `UserController.Index()` and `HomeController.Index()` for examples.

## License

This code is licensed under the terms of the MIT License. See LICENSE.txt for
more details