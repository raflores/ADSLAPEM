﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18052
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ADS.LAPEM.Resources.Catalogo {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class LAPEM_Entities_Calibracion {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal LAPEM_Entities_Calibracion() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("ADS.LAPEM.Resources.Catalogo.LAPEM_Entities_Calibracion", typeof(LAPEM_Entities_Calibracion).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to El Equipo es un campo obligatorio.
        /// </summary>
        public static string Equipo_Required {
            get {
                return ResourceManager.GetString("Equipo_Required", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to El informe solo permite caracteres númericos.
        /// </summary>
        public static string InformeNumerico {
            get {
                return ResourceManager.GetString("InformeNumerico", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to La ruta del PDF Informe es un campo obligatorio.
        /// </summary>
        public static string PDFInfo_Required {
            get {
                return ResourceManager.GetString("PDFInfo_Required", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to El Proveedor es un campo obligatorio.
        /// </summary>
        public static string Proveedor_Required {
            get {
                return ResourceManager.GetString("Proveedor_Required", resourceCulture);
            }
        }
    }
}
