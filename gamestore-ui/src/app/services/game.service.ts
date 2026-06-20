import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class GameService {

  private http = inject(HttpClient);

  private apiUrl = `${environment.apiUrl}/games`;

  getGames() {
    return this.http.get<any[]>(this.apiUrl);
  }

  getGameById(id: number) {
    return this.http.get<any>(`${this.apiUrl}/${id}`);
  }

  createGame(game: any) {
    return this.http.post<any>(this.apiUrl, game);
  }

  updateGame(id: number, game: any) {
    return this.http.put(`${this.apiUrl}/${id}`, game);
  }

  deleteGame(id: number) {
    return this.http.delete(`${this.apiUrl}/${id}`);
  }
}

