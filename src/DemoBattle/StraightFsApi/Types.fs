namespace StraightFsApi

module Types =
    [<CLIMutable>]
    type Battle = {
        Villains : int[]
        Heroes : int[]
    }

    [<CLIMutable>]
    type Fighter = {
        Id : int
        Name : string
        Class : string
        Power : int
        mutable HasBeenDefeated : bool
    }

    [<CLIMutable>]
    type FighterRepresentation = {
        Id : int
        Name : string
        Class : string
    }

    [<CLIMutable>]
    type BattleResult = {
        ResultMessage : string
        FightersLeftStanding : FighterRepresentation[]
    }