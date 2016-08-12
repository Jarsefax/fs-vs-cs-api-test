namespace StraightFsApi

open Common
open Types
open Newtonsoft.Json
open System.IO
open System.Web.Http

type VillainController() =
    inherit ApiController()

    member this.Get () =
        JsonConvert.DeserializeObject<FighterRepresentation[]>(File.ReadAllText(CommonStrings.VillainStoragePath))