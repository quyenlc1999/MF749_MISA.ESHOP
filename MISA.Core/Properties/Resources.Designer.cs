﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MISA.Core.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("MISA.Core.Properties.Resources", typeof(Resources).Assembly);
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
        ///   Looks up a localized string similar to được phép để trống.
        /// </summary>
        public static string ErrorMsg_blank {
            get {
                return ResourceManager.GetString("ErrorMsg_blank", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Xóa thất bại.
        /// </summary>
        public static string ErrorMsg_DeleteFailed {
            get {
                return ResourceManager.GetString("ErrorMsg_DeleteFailed", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Có lỗi xảy ra . Vui lòng liên hệ với MISA để được trợ giúp.
        /// </summary>
        public static string ErrorMsg_Exception {
            get {
                return ResourceManager.GetString("ErrorMsg_Exception", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to đã tồn tại trên hệ thống.
        /// </summary>
        public static string ErrorMsg_Exits {
            get {
                return ResourceManager.GetString("ErrorMsg_Exits", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Dữ liệu không hợp lệ.
        /// </summary>
        public static string ErrorMsg_Invalid {
            get {
                return ResourceManager.GetString("ErrorMsg_Invalid", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Không thêm được bản ghi vào database.Vui lòng kiểm tra lại.
        /// </summary>
        public static string ErrorMsg_NotRecordToDb {
            get {
                return ResourceManager.GetString("ErrorMsg_NotRecordToDb", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Cập nhật thất bại.
        /// </summary>
        public static string ErrorMsg_UpdateFailed {
            get {
                return ResourceManager.GetString("ErrorMsg_UpdateFailed", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Thông tin.
        /// </summary>
        public static string Info {
            get {
                return ResourceManager.GetString("Info", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Thêm mới thành công.
        /// </summary>
        public static string Msg_AddSuccess {
            get {
                return ResourceManager.GetString("Msg_AddSuccess", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Xóa thành công.
        /// </summary>
        public static string Msg_DeleteSuccess {
            get {
                return ResourceManager.GetString("Msg_DeleteSuccess", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Cập nhật thành công.
        /// </summary>
        public static string Msg_UpdateSuccess {
            get {
                return ResourceManager.GetString("Msg_UpdateSuccess", resourceCulture);
            }
        }
    }
}