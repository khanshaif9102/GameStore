import { Component, OnInit, inject, ChangeDetectorRef } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { GameService } from './services/game.service';
import { GenreService } from './services/genre.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.html',
  styleUrl: './app.css',
  standalone: true,
  imports: [CommonModule, FormsModule]
})
export class App implements OnInit {

  private gameService = inject(GameService);
  private genreService = inject(GenreService);
  private cdr = inject(ChangeDetectorRef);

  games: any[] = [];
  genres: any[] = [];

  showForm = false;
  isEditMode = false;
  editingGameId: number | null = null;

  formData = {
    name: '',
    genreId: 0,
    price: 0,
    releaseDate: ''
  };

  errorMessage = '';
  successMessage = '';

  ngOnInit(): void {
    this.loadGames();
    this.loadGenres();
  }

  loadGames(): void {
    this.gameService.getGames().subscribe({
      next: (data) => {
        this.games = data;
        this.cdr.detectChanges();
      },
      error: (err) => {
        this.showError('Error loading games: ' + err.message);
      }
    });
  }

  loadGenres(): void {
    this.genreService.getGenres().subscribe({
      next: (data) => {
        this.genres = data;
        this.cdr.detectChanges();
      },
      error: (err) => {
        this.showError('Error loading genres: ' + err.message);
      }
    });
  }

  openCreateForm(): void {
    this.isEditMode = false;
    this.editingGameId = null;
    this.resetForm();
    this.showForm = true;
    this.errorMessage = '';
  }

  openEditForm(game: any): void {
    this.isEditMode = true;
    this.editingGameId = game.id;
    this.formData = {
      name: game.name,
      genreId: game.genreId,
      price: game.price,
      releaseDate: game.releaseDate
    };
    this.showForm = true;
    this.errorMessage = '';
  }

  closeForm(): void {
    this.showForm = false;
    this.resetForm();
  }

  resetForm(): void {
    this.formData = {
      name: '',
      genreId: 0,
      price: 0,
      releaseDate: ''
    };
  }

  submitForm(): void {
    if (!this.formData.name || !this.formData.genreId || !this.formData.releaseDate) {
      this.showError('Please fill all fields');
      return;
    }

    if (this.isEditMode && this.editingGameId) {
      this.updateGame();
    } else {
      this.createGame();
    }
  }

  createGame(): void {
    this.gameService.createGame(this.formData).subscribe({
      next: () => {
        this.showSuccess('Game created successfully');
        this.closeForm();
        this.loadGames();
      },
      error: (err) => {
        this.showError('Error creating game: ' + err.error?.title || err.message);
      }
    });
  }

  updateGame(): void {
    if (!this.editingGameId) return;

    this.gameService.updateGame(this.editingGameId, this.formData).subscribe({
      next: () => {
        this.showSuccess('Game updated successfully');
        this.closeForm();
        this.loadGames();
      },
      error: (err) => {
        this.showError('Error updating game: ' + err.error?.title || err.message);
      }
    });
  }

  deleteGame(id: number): void {
    if (confirm('Are you sure you want to delete this game?')) {
      this.gameService.deleteGame(id).subscribe({
        next: () => {
          this.showSuccess('Game deleted successfully');
          this.loadGames();
        },
        error: (err) => {
          this.showError('Error deleting game: ' + err.message);
        }
      });
    }
  }

  getGenreName(genreId: number): string {
    const genre = this.genres.find(g => g.id === genreId);
    return genre ? genre.name : 'Unknown';
  }

  showError(message: string): void {
    this.errorMessage = message;
    setTimeout(() => {
      this.errorMessage = '';
    }, 5000);
  }

  showSuccess(message: string): void {
    this.successMessage = message;
    setTimeout(() => {
      this.successMessage = '';
    }, 3000);
  }
}

