namespace Umbraco.Community.DomainRestriction.Config;

public class DomainRestrictionSettings
{
	public const string SectionName = "DomainRestriction";
	public bool Enabled { get; set; } = true;
	public string UmbracoPath { get; set; } = "/umbraco";
	public string UmbracoDomain { get; set; } = "https://www.example.com";
	public string RedirectUrl { get; set; } = "/error-404";
}