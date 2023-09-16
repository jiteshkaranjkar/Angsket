import { Component, OnInit } from '@angular/core';
import { Title } from '@angular/platform-browser';
import { ConfigurationService } from './shared/services/ConfigurationService';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent implements OnInit {
  constructor(
    private titleService: Title,
    private configurationService: ConfigurationService) { }

  ngOnInit() {
    this.titleService.setTitle("Angsket");
    this.configurationService.load();
  }
}
