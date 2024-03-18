namespace InvoiceAutoScan.Common.Query;

public class QueryParams
{
    public short Limit { get; set; } = 30;
    
    public short Start { get; set; } = 0; 
    
    public string? PageToken { get; set; } = null;
    
    public short ResultCount { get; set; }
    
    public static QueryParams GetNextPage(QueryParams oldQuery)
    {
        QueryParams newQuery = new();
        
        
        
        return newQuery;
    }
}