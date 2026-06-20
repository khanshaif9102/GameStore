import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class GenreService {

  private http = inject(HttpClient);

  private apiUrl = `${environment.apiUrl}/genres`;

  getGenres() {
    return this.http.get<any[]>(this.apiUrl);
  }
}
