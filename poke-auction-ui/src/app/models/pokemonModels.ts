// models/pokemon.models.ts
export interface Pokemon {
  id: number;
  dexNumber: number;
  identifier: string;
  speciesId: number;
  height: number;
  weight: number;
  baseExperience: number;
  order: number;
  isDefault: boolean;
  evoTo?: string;
}

export interface Evolution {
  id: number;
  evolvedSpeciesId: number;
  evolutionTriggerId: number;
  triggerItemId?: number;
  minimumLevel?: number;
  genderId?: number;
  locationId?: number;
  heldItemId?: number;
  timeOfDay?: string;
  knownMoveId?: number;
  knownMoveTypeId?: number;
  minimumHappiness?: number;
  minimumBeauty?: number;
  minimumAffection?: number;
  relativePhysicalStats?: number;
  partySpeciesId?: number;
  partyTypeId?: number;
  tradeSpeciesId?: number;
  needsOverworldRain: boolean;
  turnUpsideDown: boolean;
}

export interface Move {
  id: number;
  identifier: string;
  generationId: number;
  typeId: number;
  power?: number;
  pp?: number;
  accuracy?: number;
  priority: number;
  targetId: number;
  damageClassId: number;
  effectId: number;
  effectChance?: number;
  contestTypeId?: number;
  contestEffectId?: number;
  superContestEffectId?: number;
}

export interface PokemonMove {
  pokemonId: number;
  versionGroupId: number;
  moveId: number;
  pokemonMoveMethodId: number;
  level: number;
  order?: number;
}

export interface DetailedMove {
  versionGroupId: number;
  moveId: number;
  moveName: string;
  movePower?: number;
  movePP?: number;
  moveAccuracy?: number;
  movePriority: number;
  learnLevel: number;
  learnMethod: number;
  order?: number;
}

export interface PokemonEvolutionResponse {
  originalPokemon: Pokemon;
  evolutionData: Evolution;
}

export interface PokemonMovesResponse {
  pokemon: Pokemon;
  moves: DetailedMove[];
  moveCount: number;
  versionGroup: number;
}

export interface PokemonInfoResponse {
  originalPokemon: Pokemon;
  evolutionData: Evolution;
  pokemonmoves: PokemonMove[];
}

export interface Item {
  id: number;
  identifier: string;
  categoryId: number;
  cost: number;
  flingPower?: number;
  flingEffectId?: number;
}