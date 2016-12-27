# RetrieveFavicon
Retrieve favicon from any website url using C#.

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
