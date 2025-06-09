import { bootstrapApplication } from '@angular/platform-browser';
import { AppComponent } from './app/app.component'; // Kolla att sökvägen är './app.component'
import { provideHttpClient } from '@angular/common/http';

bootstrapApplication(AppComponent, {
  providers: [provideHttpClient()]
});