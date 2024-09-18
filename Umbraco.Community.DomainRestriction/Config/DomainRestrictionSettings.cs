namespace Umbraco.Community.DomainRestriction.Config;

public class DomainRestrictionSettings
{
	public const string SectionName = "DomainRestriction";
	public bool Enabled { get; init; } = false;
	public string UmbracoPath { get; init; } = "/umbraco";
	public string UmbracoDomain { get; init; } = string.Empty;
	public string RedirectUrl { get; init; } = string.Empty;
}