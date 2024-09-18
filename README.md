# Domain Restriction For Umbraco Backoffice
Umbraco package that allows to restrict domain-based access to the backoffice.

## Installation

### Nuget
[nuget.org/packages/Umbraco.Community.DomainRestriction](https://www.nuget.org/packages/Umbraco.Community.DomainRestriction)

### Umbraco Package
[marketplace.umbraco.com/category/developer-tools](https://marketplace.umbraco.com/category/developer-tools)

## Configuration
### Appsettings
Step 1: Under appsettings, create a section called "DomainRestriction", with:
- bool `Enabled`, which enables the domain restriction
- string `UmbracoDomain`, the only allowed domain to access the backoffice
- string `UmbracoPath`, which will have a default value of `"/umbraco"`
- string `RedirectUrl`, which will have a default value of `"/error-404"`. if left empty it will return a 404 error.

``` json
"DomainRestriction": {
	"Enabled": true,
	"UmbracoPath": "/umbraco",
	"UmbracoDomain": "https://localhost:4000",
	"RedirectUrl": "/error-404"
}
```

### Startup
Step 2: In the web-project `Startup.cs` file:
``` C#
using Umbraco.Community.DomainRestriction.Extensions;
...
public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
{
	...
	app.UseDomainRestriction();
	...
}
```

#### Dealing with the 403 code
When the client domain is forbidden, the system will return a blank page. You can set up the page that the user will see following this docs:
 - [Letting Umbraco to deal with it](http://letswritecode.net/articles/how-to-setup-custom-error-pages-in-umbraco/)
 - [Letting IIS to deal with it](https://blog.mortenbock.dk/2017/02/03/error-page-setup-in-umbraco/)
