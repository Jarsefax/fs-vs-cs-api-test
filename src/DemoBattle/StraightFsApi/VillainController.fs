namespace StraightFsApi

open Types
open Newtonsoft.Json
open System.IO
open System.Web.Http

type VillainController() =
    inherit ApiController()

    member this.Get () =
        JsonConvert.DeserializeObject<Fighter[]>(File.ReadAllText(@"C:\Users\rnor\Documents\C#vsF#\Villains.txt"))