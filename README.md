# RetrieveFavicon
Retrieve favicon from any website url using C#.
A part of project [GuGuJianKong](https://github.com/ParryQiu/GuGuJianKong) backend API.

# Retrieve favicon type
* direct retrieve `$website url/favicon.ico`
* retrieve `href` from website content where contains `<link rel="* icon" href="..." />`
* retrieve `href` from website content where contains `<link rel="apple-touch-icon" href="..." />`

# Usage

```
[TestMethod]
public void CanGetFaviconIco()
{
    var faviconUrl = Common.Helper.RetrieveFavicon.Favicon.RetrieveFavicon("https://github.com/parryqiu");
    Debug.Print(faviconUrl);
    Assert.IsTrue(faviconUrl != null);
}
```

# NuGet References
* [Html Agility Pack](https://www.nuget.org/packages/HtmlAgilityPack)
