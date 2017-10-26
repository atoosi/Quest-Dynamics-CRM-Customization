﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34209
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QuestCustomization.Plugins.B1WS_Login {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="LoginService", ConfigurationName="B1WS_Login.LoginServiceSoap")]
    public interface LoginServiceSoap {
        
        // CODEGEN: Generating message contract since the wrapper namespace (http://www.sap.com/SBO/DIS) of message LoginResponse does not match the default value (LoginService)
        [System.ServiceModel.OperationContractAttribute(Action="LoginService/Login", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        QuestCustomization.Plugins.B1WS_Login.LoginResponse Login(QuestCustomization.Plugins.B1WS_Login.LoginRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="LoginService/Login", ReplyAction="*")]
        System.Threading.Tasks.Task<QuestCustomization.Plugins.B1WS_Login.LoginResponse> LoginAsync(QuestCustomization.Plugins.B1WS_Login.LoginRequest request);
        
        // CODEGEN: Generating message contract since the operation Logout is neither RPC nor document wrapped.
        [System.ServiceModel.OperationContractAttribute(Action="LoginService/Logout", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        QuestCustomization.Plugins.B1WS_Login.LogoutResponse Logout(QuestCustomization.Plugins.B1WS_Login.LogoutRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="LoginService/Logout", ReplyAction="*")]
        System.Threading.Tasks.Task<QuestCustomization.Plugins.B1WS_Login.LogoutResponse> LogoutAsync(QuestCustomization.Plugins.B1WS_Login.LogoutRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="Login", WrapperNamespace="LoginService", IsWrapped=true)]
    public partial class LoginRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="LoginService", Order=0)]
        public string DatabaseServer;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="LoginService", Order=1)]
        public string DatabaseName;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="LoginService", Order=2)]
        public string DatabaseType;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="LoginService", Order=3)]
        public string DatabaseUserName;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="LoginService", Order=4)]
        public string DatabasePassword;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="LoginService", Order=5)]
        public string CompanyUsername;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="LoginService", Order=6)]
        public string CompanyPassword;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="LoginService", Order=7)]
        public string Language;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="LoginService", Order=8)]
        public string LicenseServer;
        
        public LoginRequest() {
        }
        
        public LoginRequest(string DatabaseServer, string DatabaseName, string DatabaseType, string DatabaseUserName, string DatabasePassword, string CompanyUsername, string CompanyPassword, string Language, string LicenseServer) {
            this.DatabaseServer = DatabaseServer;
            this.DatabaseName = DatabaseName;
            this.DatabaseType = DatabaseType;
            this.DatabaseUserName = DatabaseUserName;
            this.DatabasePassword = DatabasePassword;
            this.CompanyUsername = CompanyUsername;
            this.CompanyPassword = CompanyPassword;
            this.Language = Language;
            this.LicenseServer = LicenseServer;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="LoginResponse", WrapperNamespace="http://www.sap.com/SBO/DIS", IsWrapped=true)]
    public partial class LoginResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.sap.com/SBO/DIS", Order=0)]
        public string SessionID;
        
        public LoginResponse() {
        }
        
        public LoginResponse(string SessionID) {
            this.SessionID = SessionID;
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://www.sap.com/SBO/DIS")]
    public partial class MsgHeader : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string sessionIDField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string SessionID {
            get {
                return this.sessionIDField;
            }
            set {
                this.sessionIDField = value;
                this.RaisePropertyChanged("SessionID");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="LoginService")]
    public partial class Logout : object, System.ComponentModel.INotifyPropertyChanged {
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class LogoutRequest {
        
        [System.ServiceModel.MessageHeaderAttribute(Namespace="http://www.sap.com/SBO/DIS")]
        public QuestCustomization.Plugins.B1WS_Login.MsgHeader MsgHeader;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="LoginService", Order=0)]
        public QuestCustomization.Plugins.B1WS_Login.Logout Logout;
        
        public LogoutRequest() {
        }
        
        public LogoutRequest(QuestCustomization.Plugins.B1WS_Login.MsgHeader MsgHeader, QuestCustomization.Plugins.B1WS_Login.Logout Logout) {
            this.MsgHeader = MsgHeader;
            this.Logout = Logout;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="LogoutResponse", WrapperNamespace="http://www.sap.com/SBO/DIS", IsWrapped=true)]
    public partial class LogoutResponse {
        
        public LogoutResponse() {
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface LoginServiceSoapChannel : QuestCustomization.Plugins.B1WS_Login.LoginServiceSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class LoginServiceSoapClient : System.ServiceModel.ClientBase<QuestCustomization.Plugins.B1WS_Login.LoginServiceSoap>, QuestCustomization.Plugins.B1WS_Login.LoginServiceSoap {
        
        public LoginServiceSoapClient() {
        }
        
        public LoginServiceSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public LoginServiceSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public LoginServiceSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public LoginServiceSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        QuestCustomization.Plugins.B1WS_Login.LoginResponse QuestCustomization.Plugins.B1WS_Login.LoginServiceSoap.Login(QuestCustomization.Plugins.B1WS_Login.LoginRequest request) {
            return base.Channel.Login(request);
        }
        
        public string Login(string DatabaseServer, string DatabaseName, string DatabaseType, string DatabaseUserName, string DatabasePassword, string CompanyUsername, string CompanyPassword, string Language, string LicenseServer) {
            QuestCustomization.Plugins.B1WS_Login.LoginRequest inValue = new QuestCustomization.Plugins.B1WS_Login.LoginRequest();
            inValue.DatabaseServer = DatabaseServer;
            inValue.DatabaseName = DatabaseName;
            inValue.DatabaseType = DatabaseType;
            inValue.DatabaseUserName = DatabaseUserName;
            inValue.DatabasePassword = DatabasePassword;
            inValue.CompanyUsername = CompanyUsername;
            inValue.CompanyPassword = CompanyPassword;
            inValue.Language = Language;
            inValue.LicenseServer = LicenseServer;
            QuestCustomization.Plugins.B1WS_Login.LoginResponse retVal = ((QuestCustomization.Plugins.B1WS_Login.LoginServiceSoap)(this)).Login(inValue);
            return retVal.SessionID;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<QuestCustomization.Plugins.B1WS_Login.LoginResponse> QuestCustomization.Plugins.B1WS_Login.LoginServiceSoap.LoginAsync(QuestCustomization.Plugins.B1WS_Login.LoginRequest request) {
            return base.Channel.LoginAsync(request);
        }
        
        public System.Threading.Tasks.Task<QuestCustomization.Plugins.B1WS_Login.LoginResponse> LoginAsync(string DatabaseServer, string DatabaseName, string DatabaseType, string DatabaseUserName, string DatabasePassword, string CompanyUsername, string CompanyPassword, string Language, string LicenseServer) {
            QuestCustomization.Plugins.B1WS_Login.LoginRequest inValue = new QuestCustomization.Plugins.B1WS_Login.LoginRequest();
            inValue.DatabaseServer = DatabaseServer;
            inValue.DatabaseName = DatabaseName;
            inValue.DatabaseType = DatabaseType;
            inValue.DatabaseUserName = DatabaseUserName;
            inValue.DatabasePassword = DatabasePassword;
            inValue.CompanyUsername = CompanyUsername;
            inValue.CompanyPassword = CompanyPassword;
            inValue.Language = Language;
            inValue.LicenseServer = LicenseServer;
            return ((QuestCustomization.Plugins.B1WS_Login.LoginServiceSoap)(this)).LoginAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        QuestCustomization.Plugins.B1WS_Login.LogoutResponse QuestCustomization.Plugins.B1WS_Login.LoginServiceSoap.Logout(QuestCustomization.Plugins.B1WS_Login.LogoutRequest request) {
            return base.Channel.Logout(request);
        }
        
        public void Logout(QuestCustomization.Plugins.B1WS_Login.MsgHeader MsgHeader, QuestCustomization.Plugins.B1WS_Login.Logout Logout1) {
            QuestCustomization.Plugins.B1WS_Login.LogoutRequest inValue = new QuestCustomization.Plugins.B1WS_Login.LogoutRequest();
            inValue.MsgHeader = MsgHeader;
            inValue.Logout = Logout1;
            QuestCustomization.Plugins.B1WS_Login.LogoutResponse retVal = ((QuestCustomization.Plugins.B1WS_Login.LoginServiceSoap)(this)).Logout(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<QuestCustomization.Plugins.B1WS_Login.LogoutResponse> QuestCustomization.Plugins.B1WS_Login.LoginServiceSoap.LogoutAsync(QuestCustomization.Plugins.B1WS_Login.LogoutRequest request) {
            return base.Channel.LogoutAsync(request);
        }
        
        public System.Threading.Tasks.Task<QuestCustomization.Plugins.B1WS_Login.LogoutResponse> LogoutAsync(QuestCustomization.Plugins.B1WS_Login.MsgHeader MsgHeader, QuestCustomization.Plugins.B1WS_Login.Logout Logout) {
            QuestCustomization.Plugins.B1WS_Login.LogoutRequest inValue = new QuestCustomization.Plugins.B1WS_Login.LogoutRequest();
            inValue.MsgHeader = MsgHeader;
            inValue.Logout = Logout;
            return ((QuestCustomization.Plugins.B1WS_Login.LoginServiceSoap)(this)).LogoutAsync(inValue);
        }
    }
}
