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
- bool `Enabled`, which enables and disables the 403 redirects
- string `UmbracoPath`, which will have a default value of `"/umbraco"`
- string `RedirectUrl`, which will have a default value of `"/error-404"`

``` json
"DomainRestriction": {
	"Enabled": true,
	"UmbracoPath": "/umbraco",
	"UmbracoDomain": "https://www.example.com",
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

## Usage
The package includes an http module that checks the range of ips entered on the backoffice. The values are saved on the cache so the file is not continuosly read. If the client's ip is not whitelisted it returns a 403. It's up to you to manage that code.

#### Dealing with the 403 code
When the client ip is forbidden, the system will return a 403 error (forbidden). This returns a blank page. You can set up the page that the user will see following this docs:
 - [Letting Umbraco to deal with it](http://letswritecode.net/articles/how-to-setup-custom-error-pages-in-umbraco/)
 - [Letting IIS to deal with it](https://blog.mortenbock.dk/2017/02/03/error-page-setup-in-umbraco/)
