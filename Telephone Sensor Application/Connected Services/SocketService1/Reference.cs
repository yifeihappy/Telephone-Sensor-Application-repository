﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Telephone_Sensor_Application.SocketService1 {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="SocketService1.ISocketService1")]
    public interface ISocketService1 {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISocketService1/DoWork", ReplyAction="http://tempuri.org/ISocketService1/DoWorkResponse")]
        void DoWork();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISocketService1/DoWork", ReplyAction="http://tempuri.org/ISocketService1/DoWorkResponse")]
        System.Threading.Tasks.Task DoWorkAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISocketService1/sendData", ReplyAction="http://tempuri.org/ISocketService1/sendDataResponse")]
        bool sendData(string msg);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISocketService1/sendData", ReplyAction="http://tempuri.org/ISocketService1/sendDataResponse")]
        System.Threading.Tasks.Task<bool> sendDataAsync(string msg);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ISocketService1Channel : Telephone_Sensor_Application.SocketService1.ISocketService1, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class SocketService1Client : System.ServiceModel.ClientBase<Telephone_Sensor_Application.SocketService1.ISocketService1>, Telephone_Sensor_Application.SocketService1.ISocketService1 {
        
        public SocketService1Client() {
        }
        
        public SocketService1Client(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public SocketService1Client(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public SocketService1Client(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public SocketService1Client(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public void DoWork() {
            base.Channel.DoWork();
        }
        
        public System.Threading.Tasks.Task DoWorkAsync() {
            return base.Channel.DoWorkAsync();
        }
        
        public bool sendData(string msg) {
            return base.Channel.sendData(msg);
        }
        
        public System.Threading.Tasks.Task<bool> sendDataAsync(string msg) {
            return base.Channel.sendDataAsync(msg);
        }
    }
}