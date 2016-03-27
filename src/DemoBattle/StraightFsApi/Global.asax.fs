namespace StraightFsApi

open System
open System.Net.Http
open System.Web
open System.Web.Http
open System.Web.Routing

type HttpRoute = {
    controller : string
    id : RouteParameter }

type Global() =
    inherit System.Web.HttpApplication() 

    static member Register(config: HttpConfiguration) =
        config.EnableCors();

        // Web API routes
        config.MapHttpAttributeRoutes()        

        // Configure serialization
//        config.Formatters.XmlFormatter.UseXmlSerializer <- true
//        config.Formatters.JsonFormatter.SerializerSettings.ContractResolver <- Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver()

    member x.Application_Start() =
        GlobalConfiguration.Configure(Action<_> Global.Register)