﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AlmostSurely.Utilities.Console.AlmostSurelyServiceReference {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="AlmostSurelyServiceReference.IAlmostSurelyService")]
    public interface IAlmostSurelyService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAlmostSurelyService/GetNewImages", ReplyAction="http://tempuri.org/IAlmostSurelyService/GetNewImagesResponse")]
        AlmostSurely.Utilities.Console.AlmostSurelyServiceReference.GetNewImagesResponse GetNewImages(AlmostSurely.Utilities.Console.AlmostSurelyServiceReference.GetNewImagesRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAlmostSurelyService/GetNewImages", ReplyAction="http://tempuri.org/IAlmostSurelyService/GetNewImagesResponse")]
        System.Threading.Tasks.Task<AlmostSurely.Utilities.Console.AlmostSurelyServiceReference.GetNewImagesResponse> GetNewImagesAsync(AlmostSurely.Utilities.Console.AlmostSurelyServiceReference.GetNewImagesRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="GetNewImages", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class GetNewImagesRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public AlmostSurely.Processors.ProcessContainerBase container;
        
        public GetNewImagesRequest() {
        }
        
        public GetNewImagesRequest(AlmostSurely.Processors.ProcessContainerBase container) {
            this.container = container;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="GetNewImagesResponse", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class GetNewImagesResponse {
        
        public GetNewImagesResponse() {
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IAlmostSurelyServiceChannel : AlmostSurely.Utilities.Console.AlmostSurelyServiceReference.IAlmostSurelyService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class AlmostSurelyServiceClient : System.ServiceModel.ClientBase<AlmostSurely.Utilities.Console.AlmostSurelyServiceReference.IAlmostSurelyService>, AlmostSurely.Utilities.Console.AlmostSurelyServiceReference.IAlmostSurelyService {
        
        public AlmostSurelyServiceClient() {
        }
        
        public AlmostSurelyServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public AlmostSurelyServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public AlmostSurelyServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public AlmostSurelyServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public AlmostSurely.Utilities.Console.AlmostSurelyServiceReference.GetNewImagesResponse GetNewImages(AlmostSurely.Utilities.Console.AlmostSurelyServiceReference.GetNewImagesRequest request) {
            return base.Channel.GetNewImages(request);
        }
        
        public System.Threading.Tasks.Task<AlmostSurely.Utilities.Console.AlmostSurelyServiceReference.GetNewImagesResponse> GetNewImagesAsync(AlmostSurely.Utilities.Console.AlmostSurelyServiceReference.GetNewImagesRequest request) {
            return base.Channel.GetNewImagesAsync(request);
        }
    }
}
