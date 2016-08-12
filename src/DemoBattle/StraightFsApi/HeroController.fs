namespace StraightFsApi

open Common
open Types
open Newtonsoft.Json
open System.IO
open System.Web.Http

type HeroController() =
    inherit ApiController()

    member this.Get () =
        JsonConvert.DeserializeObject<FighterRepresentation[]>(File.ReadAllText(CommonStrings.HeroStoragePath))