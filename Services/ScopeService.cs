namespace Pharmatic.Services
{
    public class ScopeService
    {
        private static List<Scope> predefinedScopes = new List<Scope>
    {
        new Scope { Category = "Providers", 
                    Notes = "Manejo de proveedores en las facturas de compra de manera opcional y de manera requerida en facturas de devolución.", 
                    AccessLevel = "provider" },

        new Scope { Category = "Customers", 
                    Notes = "Manejo de clientes regulares en las facturas de venta de manera opcional." ,
                    AccessLevel = "customer" },

        new Scope { Category = "Products", 
                    Notes = "Manejo de los productos y sus propiedades." ,
                    AccessLevel = "product" },

        new Scope { Category = "Lots", 
                    Notes = "Manejo del inventario." ,
                    AccessLevel = "inventory" },

        new Scope { Category = "Sales Invoice", 
                    Notes = "Factura de venta." ,
                    AccessLevel = "sales" },

        new Scope { Category = "Purchase Invoice", 
                    Notes = "Factura de compra." ,
                    AccessLevel = "purchase" },

        new Scope { Category = "Return Invoice", 
                    Notes = "Factura de devolución." ,
                    AccessLevel = "returns" },

        new Scope { Category = "Users",
                    Notes = "Administración de usuarios." ,
                    AccessLevel = "user" },
    };

        public List<Scope> GetScopes()
        {
            return predefinedScopes;
        }
    }

    public class Scope
    {
        public string Category { get; set; }
        public string Notes { get; set; }
        public string AccessLevel {  get; set; }

        bool read = false;
        bool write = false;
        bool delete = false;
    }

}
