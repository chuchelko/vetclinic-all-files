// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: Protos/services.proto
// </auto-generated>
#pragma warning disable 0414, 1591
#region Designer generated code

using grpc = global::Grpc.Core;

namespace API.gRPCService {
  public static partial class ServicesService
  {
    static readonly string __ServiceName = "services_package.ServicesService";

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static void __Helper_SerializeMessage(global::Google.Protobuf.IMessage message, grpc::SerializationContext context)
    {
      #if !GRPC_DISABLE_PROTOBUF_BUFFER_SERIALIZATION
      if (message is global::Google.Protobuf.IBufferMessage)
      {
        context.SetPayloadLength(message.CalculateSize());
        global::Google.Protobuf.MessageExtensions.WriteTo(message, context.GetBufferWriter());
        context.Complete();
        return;
      }
      #endif
      context.Complete(global::Google.Protobuf.MessageExtensions.ToByteArray(message));
    }

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static class __Helper_MessageCache<T>
    {
      public static readonly bool IsBufferMessage = global::System.Reflection.IntrospectionExtensions.GetTypeInfo(typeof(global::Google.Protobuf.IBufferMessage)).IsAssignableFrom(typeof(T));
    }

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static T __Helper_DeserializeMessage<T>(grpc::DeserializationContext context, global::Google.Protobuf.MessageParser<T> parser) where T : global::Google.Protobuf.IMessage<T>
    {
      #if !GRPC_DISABLE_PROTOBUF_BUFFER_SERIALIZATION
      if (__Helper_MessageCache<T>.IsBufferMessage)
      {
        return parser.ParseFrom(context.PayloadAsReadOnlySequence());
      }
      #endif
      return parser.ParseFrom(context.PayloadAsNewBuffer());
    }

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::API.gRPCService.GetAllServicesRequest> __Marshaller_services_package_GetAllServicesRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::API.gRPCService.GetAllServicesRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::API.gRPCService.GetAllServicesResponse> __Marshaller_services_package_GetAllServicesResponse = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::API.gRPCService.GetAllServicesResponse.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::API.gRPCService.GetProvidedServicesRequest> __Marshaller_services_package_GetProvidedServicesRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::API.gRPCService.GetProvidedServicesRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::API.gRPCService.GetProvidedServicesResponse> __Marshaller_services_package_GetProvidedServicesResponse = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::API.gRPCService.GetProvidedServicesResponse.Parser));

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::API.gRPCService.GetAllServicesRequest, global::API.gRPCService.GetAllServicesResponse> __Method_GetAllServices = new grpc::Method<global::API.gRPCService.GetAllServicesRequest, global::API.gRPCService.GetAllServicesResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "GetAllServices",
        __Marshaller_services_package_GetAllServicesRequest,
        __Marshaller_services_package_GetAllServicesResponse);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::API.gRPCService.GetProvidedServicesRequest, global::API.gRPCService.GetProvidedServicesResponse> __Method_GetProvidedServices = new grpc::Method<global::API.gRPCService.GetProvidedServicesRequest, global::API.gRPCService.GetProvidedServicesResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "GetProvidedServices",
        __Marshaller_services_package_GetProvidedServicesRequest,
        __Marshaller_services_package_GetProvidedServicesResponse);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::API.gRPCService.ServicesReflection.Descriptor.Services[0]; }
    }

    /// <summary>Base class for server-side implementations of ServicesService</summary>
    [grpc::BindServiceMethod(typeof(ServicesService), "BindService")]
    public abstract partial class ServicesServiceBase
    {
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::API.gRPCService.GetAllServicesResponse> GetAllServices(global::API.gRPCService.GetAllServicesRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::API.gRPCService.GetProvidedServicesResponse> GetProvidedServices(global::API.gRPCService.GetProvidedServicesRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

    }

    /// <summary>Creates service definition that can be registered with a server</summary>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    public static grpc::ServerServiceDefinition BindService(ServicesServiceBase serviceImpl)
    {
      return grpc::ServerServiceDefinition.CreateBuilder()
          .AddMethod(__Method_GetAllServices, serviceImpl.GetAllServices)
          .AddMethod(__Method_GetProvidedServices, serviceImpl.GetProvidedServices).Build();
    }

    /// <summary>Register service method with a service binder with or without implementation. Useful when customizing the  service binding logic.
    /// Note: this method is part of an experimental API that can change or be removed without any prior notice.</summary>
    /// <param name="serviceBinder">Service methods will be bound by calling <c>AddMethod</c> on this object.</param>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    public static void BindService(grpc::ServiceBinderBase serviceBinder, ServicesServiceBase serviceImpl)
    {
      serviceBinder.AddMethod(__Method_GetAllServices, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::API.gRPCService.GetAllServicesRequest, global::API.gRPCService.GetAllServicesResponse>(serviceImpl.GetAllServices));
      serviceBinder.AddMethod(__Method_GetProvidedServices, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::API.gRPCService.GetProvidedServicesRequest, global::API.gRPCService.GetProvidedServicesResponse>(serviceImpl.GetProvidedServices));
    }

  }
}
#endregion