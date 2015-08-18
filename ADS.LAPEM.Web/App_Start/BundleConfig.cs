using System.Web;
using System.Web.Optimization;

namespace ADS.LAPEM.Web
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            BundleTable.EnableOptimizations = false;

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                        "~/Scripts/jquery-ui-{version}.js",
                        "~/Scripts/jquery.jqGrid.js",
                        "~/Scripts/i18n/grid.locale-es.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryplugin").Include(
                       "~/Scripts/jquery.maskedinput-1.3.1.min.js"));


            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.unobtrusive*",
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/ads").Include(
                       "~/Scripts/ADS/ADS.js"
           ));

            bundles.Add(new ScriptBundle("~/bundles/knockout").Include(
                        "~/Scripts/knockout-2.3.0.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/ads/example").Include(
                        "~/Scripts/ADS/Example/ADS.Example.js",
                        "~/Scripts/ADS/Example/ADS.Example.Person.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/ads/consulta").Include(
                        "~/Scripts/ADS/Consulta/ADS.Consulta.js",
                        "~/Scripts/ADS/Consulta/ADS.Consulta.Historica.js",
                        "~/Scripts/ADS/Consulta/ADS.Consulta.Lote.js",
                        "~/Scripts/ADS/Consulta/ADS.Consulta.Log.js",
                        "~/Scripts/ADS/Consulta/ADS.Consulta.Linea.js",
                        "~/Scripts/ADS/Consulta/ADS.Consulta.Aviso.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/ads/reporte").Include(
                        "~/Scripts/ADS/Reporte/ADS.Reporte.js",
                        "~/Scripts/ADS/Reporte/ADS.Reporte.Reporteador.js",
                        "~/Scripts/ADS/Reporte/ADS.Reporte.Agrietamiento.js",
                        "~/Scripts/ADS/Reporte/ADS.Reporte.Aplastamiento.js",
                        "~/Scripts/ADS/Reporte/ADS.Reporte.CaracteristicasF.js",
                        "~/Scripts/ADS/Reporte/ADS.Reporte.Dimensional.js",
                        "~/Scripts/ADS/Reporte/ADS.Reporte.Espesores.js",
                        "~/Scripts/ADS/Reporte/ADS.Reporte.Hermeticidad.js",
                        "~/Scripts/ADS/Reporte/ADS.Reporte.Impacto.js",
                        "~/Scripts/ADS/Reporte/ADS.Reporte.Rigidez.js",
                        "~/Scripts/ADS/Reporte/ADS.Reporte.Test.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/ads/seguridad").Include(
                       "~/Scripts/ADS/Seguridad/ADS.Seguridad.js",
                       "~/Scripts/ADS/Seguridad/ADS.Seguridad.Account.js",
                       "~/Scripts/ADS/Seguridad/ADS.Seguridad.Perfil.js",
                       "~/Scripts/ADS/Seguridad/ADS.Seguridad.PerfilMenu.js",
                        "~/Scripts/ADS/Seguridad/ADS.Seguridad.Usuario.js"
           ));

            bundles.Add(new ScriptBundle("~/bundles/ads/catalogo").Include(
                       "~/Scripts/ADS/Catalogo/ADS.Catalogo.js",
                       "~/Scripts/ADS/Catalogo/ADS.Catalogo.AvisoPrueba.js",
                       "~/Scripts/ADS/Catalogo/ADS.Catalogo.Calibracion.js",
                       "~/Scripts/ADS/Catalogo/ADS.Catalogo.Color.js",
                       "~/Scripts/ADS/Catalogo/ADS.Catalogo.Equipo.js",
                       "~/Scripts/ADS/Catalogo/ADS.Catalogo.EnsayoEquipo.js",
                       "~/Scripts/ADS/Catalogo/ADS.Catalogo.Especificacion.js",                       
                       "~/Scripts/ADS/Catalogo/ADS.Catalogo.Linea.js",
                       "~/Scripts/ADS/Catalogo/ADS.Catalogo.Norma.js",
                       "~/Scripts/ADS/Catalogo/ADS.Catalogo.NormaEnsayo.js",
                       "~/Scripts/ADS/Catalogo/ADS.Catalogo.NormaProducto.js",
                       "~/Scripts/ADS/Catalogo/ADS.Catalogo.Producto.js",
                       "~/Scripts/ADS/Catalogo/ADS.Catalogo.Planta.js",
                       "~/Scripts/ADS/Catalogo/ADS.Catalogo.Proveedor.js",                       
                       "~/Scripts/ADS/Catalogo/ADS.Catalogo.Silo.js",
                       "~/Scripts/ADS/Catalogo/ADS.Catalogo.TipoProducto.js",
                       "~/Scripts/ADS/Catalogo/ADS.Catalogo.TipoPrueba.js",
                       "~/Scripts/ADS/Catalogo/ADS.Catalogo.Turno.js"
           ));
           

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/themes/overcast/css").Include(
                        "~/Content/themes/overcast/jquery-ui-1.10.3.custom.css",
                        "~/Content/jquery.jqGrid/ui.jqgrid.css"));

            bundles.Add(new StyleBundle("~/Content/themes/south-street/css").Include(
                        "~/Content/themes/south-street/jquery-ui-1.10.3.custom.css",
                        "~/Content/jquery.jqGrid/ui.jqgrid.css"));

            bundles.Add(new StyleBundle("~/Content/themes/base/css").Include(
                        "~/Content/themes/base/jquery.ui.core.css",
                        "~/Content/themes/base/jquery.ui.resizable.css",
                        "~/Content/themes/base/jquery.ui.selectable.css",
                        "~/Content/themes/base/jquery.ui.accordion.css",
                        "~/Content/themes/base/jquery.ui.autocomplete.css",
                        "~/Content/themes/base/jquery.ui.button.css",
                        "~/Content/themes/base/jquery.ui.dialog.css",
                        "~/Content/themes/base/jquery.ui.slider.css",
                        "~/Content/themes/base/jquery.ui.tabs.css",
                        "~/Content/themes/base/jquery.ui.datepicker.css",
                        "~/Content/themes/base/jquery.ui.progressbar.css",
                        "~/Content/themes/base/jquery.ui.theme.css"));
        }
    }
}