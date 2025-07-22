// services/pokemon.service.ts
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { 
  Pokemon, 
  Evolution, 
  Move, 
  PokemonMove, 
  Item,
  PokemonEvolutionResponse,
  PokemonMovesResponse,
  PokemonInfoResponse
} from '../models/pokemonModels';

@Injectable({
  providedIn: 'root'
})
export class PokemonService {
  private apiUrl = 'http://localhost:5298/api/pokemon'; // Replace with your backend URL

  constructor(private http: HttpClient) { }

  // Pokemon endpoints
  getAllPokemon(): Observable<Pokemon[]> {
    return this.http.get<Pokemon[]>(`${this.apiUrl}/pokemon/all`);
  }

  getPokemonById(id: number): Observable<Pokemon> {
    return this.http.get<Pokemon>(`${this.apiUrl}/${id}`);
  }

  getPokemonByDex(dexNumber: number): Observable<Pokemon> {
    return this.http.get<Pokemon>(`${this.apiUrl}/by-dex/${dexNumber}`);
  }

  getAllPokemonInfo(pokemonId: number): Observable<PokemonInfoResponse> {
    return this.http.get<PokemonInfoResponse>(`${this.apiUrl}/info/${pokemonId}`);
  }

  // Evolution endpoints
  getAllEvolution(): Observable<Evolution[]> {
    return this.http.get<Evolution[]>(`${this.apiUrl}/evolution/all`);
  }

  getPokemonEvolution(pokemonId: number): Observable<PokemonEvolutionResponse> {
    return this.http.get<PokemonEvolutionResponse>(`${this.apiUrl}/evolution/${pokemonId}`);
  }

  // Move endpoints
  getAllMoves(): Observable<Move[]> {
    return this.http.get<Move[]>(`${this.apiUrl}/move/all`);
  }

  getPokemonMovesDetailed(pokemonId: number): Observable<PokemonMovesResponse> {
    return this.http.get<PokemonMovesResponse>(`${this.apiUrl}/moves-detailed/${pokemonId}`);
  }

  getPokemonMovesDetailedByVersion(pokemonId: number, versionGroupId: number): Observable<PokemonMovesResponse> {
    return this.http.get<PokemonMovesResponse>(`${this.apiUrl}/moves-detailed/${pokemonId}/version/${versionGroupId}`);
  }

  getAllPokemonMoves(): Observable<PokemonMove[]> {
    return this.http.get<PokemonMove[]>(`${this.apiUrl}/pokemonmove/all`);
  }

  // Item endpoints
  getAllItems(): Observable<Item[]> {
    return this.http.get<Item[]>(`${this.apiUrl}/item/all`);
  }

  // Debug endpoints
  getDebugInfo(): Observable<any> {
    return this.http.get<any>(`${this.apiUrl}/debug`);
  }

  getConnectionInfo(): Observable<any> {
    return this.http.get<any>(`${this.apiUrl}/connection-info`);
  }
}