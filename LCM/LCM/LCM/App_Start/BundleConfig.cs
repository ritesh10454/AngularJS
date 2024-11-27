using System.Web;
using System.Web.Optimization;

namespace LCM
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            //js  
            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(  
                "~/Scripts/jquery-ui-{version}.js"));  
            //css  
            bundles.Add(new StyleBundle("~/Content/cssjqryUi").Include(  
            "~/Content/jquery-ui.css"));

            //bundles.Add(new StyleBundle("~/angularUpload/css").Include(
            //"~/angular-1.8.0/uploadangular/src/directives/btnUpload.min.css"));

            bundles.Add(new StyleBundle("~/angularUpload/js").Include(
            //"~/angular-1.8.0/uploadangular/angular-upload.js"
            "~/Scripts/ng-file-upload.min.js"
            ));
            


            bundles.Add(new StyleBundle("~/Content/PrintOut").Include("~/Content/PrintOut.css"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.bundle.min.js"));


 bundles.Add(new StyleBundle("~/Content/css").Include(
                        "~/mash-able/bower_components/bootstrap/css/bootstrap.min.css",
                        "~/mash-able/dark/assets/icon/themify-icons/themify-icons.css",
                        "~/mash-able/dark/assets/icon/icofont/css/icofont.css",
                        "~/mash-able/dark/assets/pages/flag-icon/flag-icon.min.css",
                        "~/mash-able/dark/assets/css/style.css",
                        "~/mash-able/dark/assets/css/linearicons.css",
                        "~/mash-able/dark/assets/css/simple-line-icons.css",
                        "~/mash-able/dark/assets/css/ionicons.css",
                        "~/mash-able/dark/assets/css/jquery.mCustomScrollbar.css",
                        "~/mash-able/dark/assets/css/pcoded-horizontal.min.css",
                        "~/mash-able/external.css",
                        "~/Content/themes/base/core.css",
                        "~/Content/themes/base/theme.css",
                        "~/Content/themes/base/datepicker.css",
                        "~/adminlte/plugins/summernote/summernote-bs4.min.css",
                        "~/adminlte/plugins/datatables-fixedcolumns/css/fixedColumns.bootstrap4.min.css",
                        "~/adminlte/plugins/daterangepicker/daterangepicker.css",
                        "~/adminlte/plugins/fullcalendar/main.min.css",
                        "~/adminlte/plugins/datatables-bs4/css/dataTables.bootstrap4.min.css",
                        "~/Content/themes/base/jquery.ui.datepicker.css",
                        "~/Content/toaster.css"
                      //, "~/Content/site.css"
                      //"~/adminlte/css/adminlte.min.css",
                      // "~/adminlte/css/freecss.css",
                      ));


            bundles.Add(new ScriptBundle("~/mashable/js").Include(
                            "~/mash-able/bower_components/popperjs/js/popper.min.js",
                            //"~/mash-able/bower_components/bootstrap/js/bootstrap.min.js",
                            "~/mash-able/bower_components/jquery-slimscroll/js/jquery.slimscroll.js",
                            "~/mash-able/bower_components/i18next/js/i18next.min.js",
                            "~/mash-able/bower_components/i18next-xhr-backend/js/i18nextXHRBackend.min.js",
                            "~/mash-able/bower_components/jquery-i18next/js/jquery-i18next.min.js",
                            "~/mash-able/dark/assets/js/script.js",
                            "~/mash-able/dark/assets/js/pcoded.min.js",
                            "~/mash-able/dark/assets/js/demo-10.js",
                            //"~/adminlte/js/adminlte.min.js",
                            "~/mash-able/dark/assets/pages/data-table/js/jszip.min.js",
                            "~/mash-able/dark/assets/pages/data-table/js/pdfmake.min.js",
                            "~/mash-able/dark/assets/pages/data-table/js/vfs_fonts.js",
                            "~/Scripts/jquery.ui.datepicker.min.js",

                            //"~/mash-able/dark/assets/pages/data-table/extensions/responsive/js/dataTables.responsive.min.js",
                            //"~/mash-able/bower_components/datatables.net-buttons/js/buttons.print.min.js",
                            //"~/mash-able/bower_components/datatables.net-buttons/js/buttons.html5.min.js",
                            "~/adminlte/plugins/summernote/summernote-bs4.min.js",
                            "~/adminlte/plugins/datatables/jquery.dataTables.min.js",
                            "~/adminlte/plugins/datatables-fixedcolumns/js/dataTables.fixedColumns.min.js",
                            //"~/adminlte//plugins/daterangepicker/daterangepicker.js",
                            "~/adminlte/plugins/datatables-bs4/js/dataTables.bootstrap4.js"
                        ));

            bundles.Add(new ScriptBundle("~/angular/js").Include(
                    "~/angular-1.8.0/angular.js",
                    //"~/angular-1.8.0/angular.min.js",
                    "~/angular-1.8.0/angular-animate.min.js",
                    "~/angular-1.8.0/angular-datatables.min.js",
                    //"~/angular-1.8.0/angular-messages.min.js",
                    //"~/Scripts/angular-route.js",
                    "~/angular-1.8.0/toaster.js",
                    "~/AngularJSCode/MastersCode.js"
                ));


        }
    }
}
