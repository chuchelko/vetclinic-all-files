// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: Protos/appointment.proto
// </auto-generated>
#pragma warning disable 0414, 1591
#region Designer generated code

using grpc = global::Grpc.Core;

namespace API.gRPCService {
  public static partial class AppointmentService
  {
    static readonly string __ServiceName = "appointment_package.AppointmentService";

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
    static readonly grpc::Marshaller<global::API.gRPCService.CreateAppointmentRequest> __Marshaller_appointment_package_CreateAppointmentRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::API.gRPCService.CreateAppointmentRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::API.gRPCService.CreateAppointmentResponse> __Marshaller_appointment_package_CreateAppointmentResponse = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::API.gRPCService.CreateAppointmentResponse.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::API.gRPCService.GetWeekAppointmentsRequest> __Marshaller_appointment_package_GetWeekAppointmentsRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::API.gRPCService.GetWeekAppointmentsRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::API.gRPCService.GetWeekAppointmentsResponse> __Marshaller_appointment_package_GetWeekAppointmentsResponse = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::API.gRPCService.GetWeekAppointmentsResponse.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::API.gRPCService.GetOwnerAppointmentsRequest> __Marshaller_appointment_package_GetOwnerAppointmentsRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::API.gRPCService.GetOwnerAppointmentsRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::API.gRPCService.GetOwnerAppointmentsResponse> __Marshaller_appointment_package_GetOwnerAppointmentsResponse = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::API.gRPCService.GetOwnerAppointmentsResponse.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::API.gRPCService.CancelAppointmentRequest> __Marshaller_appointment_package_CancelAppointmentRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::API.gRPCService.CancelAppointmentRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::API.gRPCService.CancelAppointmentResponse> __Marshaller_appointment_package_CancelAppointmentResponse = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::API.gRPCService.CancelAppointmentResponse.Parser));

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::API.gRPCService.CreateAppointmentRequest, global::API.gRPCService.CreateAppointmentResponse> __Method_CreateAppointment = new grpc::Method<global::API.gRPCService.CreateAppointmentRequest, global::API.gRPCService.CreateAppointmentResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "CreateAppointment",
        __Marshaller_appointment_package_CreateAppointmentRequest,
        __Marshaller_appointment_package_CreateAppointmentResponse);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::API.gRPCService.GetWeekAppointmentsRequest, global::API.gRPCService.GetWeekAppointmentsResponse> __Method_GetAvailableWeekAppointments = new grpc::Method<global::API.gRPCService.GetWeekAppointmentsRequest, global::API.gRPCService.GetWeekAppointmentsResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "GetAvailableWeekAppointments",
        __Marshaller_appointment_package_GetWeekAppointmentsRequest,
        __Marshaller_appointment_package_GetWeekAppointmentsResponse);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::API.gRPCService.GetOwnerAppointmentsRequest, global::API.gRPCService.GetOwnerAppointmentsResponse> __Method_GetOwnerAppointments = new grpc::Method<global::API.gRPCService.GetOwnerAppointmentsRequest, global::API.gRPCService.GetOwnerAppointmentsResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "GetOwnerAppointments",
        __Marshaller_appointment_package_GetOwnerAppointmentsRequest,
        __Marshaller_appointment_package_GetOwnerAppointmentsResponse);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::API.gRPCService.CancelAppointmentRequest, global::API.gRPCService.CancelAppointmentResponse> __Method_CancelAppointment = new grpc::Method<global::API.gRPCService.CancelAppointmentRequest, global::API.gRPCService.CancelAppointmentResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "CancelAppointment",
        __Marshaller_appointment_package_CancelAppointmentRequest,
        __Marshaller_appointment_package_CancelAppointmentResponse);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::API.gRPCService.AppointmentReflection.Descriptor.Services[0]; }
    }

    /// <summary>Base class for server-side implementations of AppointmentService</summary>
    [grpc::BindServiceMethod(typeof(AppointmentService), "BindService")]
    public abstract partial class AppointmentServiceBase
    {
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::API.gRPCService.CreateAppointmentResponse> CreateAppointment(global::API.gRPCService.CreateAppointmentRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::API.gRPCService.GetWeekAppointmentsResponse> GetAvailableWeekAppointments(global::API.gRPCService.GetWeekAppointmentsRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::API.gRPCService.GetOwnerAppointmentsResponse> GetOwnerAppointments(global::API.gRPCService.GetOwnerAppointmentsRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::API.gRPCService.CancelAppointmentResponse> CancelAppointment(global::API.gRPCService.CancelAppointmentRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

    }

    /// <summary>Creates service definition that can be registered with a server</summary>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    public static grpc::ServerServiceDefinition BindService(AppointmentServiceBase serviceImpl)
    {
      return grpc::ServerServiceDefinition.CreateBuilder()
          .AddMethod(__Method_CreateAppointment, serviceImpl.CreateAppointment)
          .AddMethod(__Method_GetAvailableWeekAppointments, serviceImpl.GetAvailableWeekAppointments)
          .AddMethod(__Method_GetOwnerAppointments, serviceImpl.GetOwnerAppointments)
          .AddMethod(__Method_CancelAppointment, serviceImpl.CancelAppointment).Build();
    }

    /// <summary>Register service method with a service binder with or without implementation. Useful when customizing the  service binding logic.
    /// Note: this method is part of an experimental API that can change or be removed without any prior notice.</summary>
    /// <param name="serviceBinder">Service methods will be bound by calling <c>AddMethod</c> on this object.</param>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    public static void BindService(grpc::ServiceBinderBase serviceBinder, AppointmentServiceBase serviceImpl)
    {
      serviceBinder.AddMethod(__Method_CreateAppointment, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::API.gRPCService.CreateAppointmentRequest, global::API.gRPCService.CreateAppointmentResponse>(serviceImpl.CreateAppointment));
      serviceBinder.AddMethod(__Method_GetAvailableWeekAppointments, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::API.gRPCService.GetWeekAppointmentsRequest, global::API.gRPCService.GetWeekAppointmentsResponse>(serviceImpl.GetAvailableWeekAppointments));
      serviceBinder.AddMethod(__Method_GetOwnerAppointments, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::API.gRPCService.GetOwnerAppointmentsRequest, global::API.gRPCService.GetOwnerAppointmentsResponse>(serviceImpl.GetOwnerAppointments));
      serviceBinder.AddMethod(__Method_CancelAppointment, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::API.gRPCService.CancelAppointmentRequest, global::API.gRPCService.CancelAppointmentResponse>(serviceImpl.CancelAppointment));
    }

  }
}
#endregion