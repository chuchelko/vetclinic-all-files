// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: Protos/appointment.proto
// </auto-generated>
#pragma warning disable 0414, 1591, 8981
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

    /// <summary>Client for AppointmentService</summary>
    public partial class AppointmentServiceClient : grpc::ClientBase<AppointmentServiceClient>
    {
      /// <summary>Creates a new client for AppointmentService</summary>
      /// <param name="channel">The channel to use to make remote calls.</param>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public AppointmentServiceClient(grpc::ChannelBase channel) : base(channel)
      {
      }
      /// <summary>Creates a new client for AppointmentService that uses a custom <c>CallInvoker</c>.</summary>
      /// <param name="callInvoker">The callInvoker to use to make remote calls.</param>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public AppointmentServiceClient(grpc::CallInvoker callInvoker) : base(callInvoker)
      {
      }
      /// <summary>Protected parameterless constructor to allow creation of test doubles.</summary>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      protected AppointmentServiceClient() : base()
      {
      }
      /// <summary>Protected constructor to allow creation of configured clients.</summary>
      /// <param name="configuration">The client configuration.</param>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      protected AppointmentServiceClient(ClientBaseConfiguration configuration) : base(configuration)
      {
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::API.gRPCService.CreateAppointmentResponse CreateAppointment(global::API.gRPCService.CreateAppointmentRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return CreateAppointment(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::API.gRPCService.CreateAppointmentResponse CreateAppointment(global::API.gRPCService.CreateAppointmentRequest request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_CreateAppointment, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::API.gRPCService.CreateAppointmentResponse> CreateAppointmentAsync(global::API.gRPCService.CreateAppointmentRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return CreateAppointmentAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::API.gRPCService.CreateAppointmentResponse> CreateAppointmentAsync(global::API.gRPCService.CreateAppointmentRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_CreateAppointment, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::API.gRPCService.GetWeekAppointmentsResponse GetAvailableWeekAppointments(global::API.gRPCService.GetWeekAppointmentsRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return GetAvailableWeekAppointments(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::API.gRPCService.GetWeekAppointmentsResponse GetAvailableWeekAppointments(global::API.gRPCService.GetWeekAppointmentsRequest request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_GetAvailableWeekAppointments, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::API.gRPCService.GetWeekAppointmentsResponse> GetAvailableWeekAppointmentsAsync(global::API.gRPCService.GetWeekAppointmentsRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return GetAvailableWeekAppointmentsAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::API.gRPCService.GetWeekAppointmentsResponse> GetAvailableWeekAppointmentsAsync(global::API.gRPCService.GetWeekAppointmentsRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_GetAvailableWeekAppointments, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::API.gRPCService.GetOwnerAppointmentsResponse GetOwnerAppointments(global::API.gRPCService.GetOwnerAppointmentsRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return GetOwnerAppointments(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::API.gRPCService.GetOwnerAppointmentsResponse GetOwnerAppointments(global::API.gRPCService.GetOwnerAppointmentsRequest request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_GetOwnerAppointments, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::API.gRPCService.GetOwnerAppointmentsResponse> GetOwnerAppointmentsAsync(global::API.gRPCService.GetOwnerAppointmentsRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return GetOwnerAppointmentsAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::API.gRPCService.GetOwnerAppointmentsResponse> GetOwnerAppointmentsAsync(global::API.gRPCService.GetOwnerAppointmentsRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_GetOwnerAppointments, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::API.gRPCService.CancelAppointmentResponse CancelAppointment(global::API.gRPCService.CancelAppointmentRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return CancelAppointment(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::API.gRPCService.CancelAppointmentResponse CancelAppointment(global::API.gRPCService.CancelAppointmentRequest request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_CancelAppointment, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::API.gRPCService.CancelAppointmentResponse> CancelAppointmentAsync(global::API.gRPCService.CancelAppointmentRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return CancelAppointmentAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::API.gRPCService.CancelAppointmentResponse> CancelAppointmentAsync(global::API.gRPCService.CancelAppointmentRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_CancelAppointment, null, options, request);
      }
      /// <summary>Creates a new instance of client from given <c>ClientBaseConfiguration</c>.</summary>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      protected override AppointmentServiceClient NewInstance(ClientBaseConfiguration configuration)
      {
        return new AppointmentServiceClient(configuration);
      }
    }

  }
}
#endregion