using System;

[Serializable]
public class SearchURL
{
    public string type;
}

[Serializable]
public class SearchQueries
{
}

[Serializable]
public class SearchContext
{
}
[Serializable]
public class SearchInformation
{
}

[Serializable]
public class SearchItem
{
    public string kind;
    public string title;
    public string link;
    public string displayLink;
    public string mime;
    public SearchImage image;
}

[Serializable]
public class SearchImage
{
    public string contextLink;
    public string thumbnailLink;
}

[Serializable]
public class SearchResult
{
    public string kind;
    public SearchURL url;
    public SearchQueries queries;
    public SearchContext context;
    public SearchInformation searchInformation;
    public SearchItem[] items;
}