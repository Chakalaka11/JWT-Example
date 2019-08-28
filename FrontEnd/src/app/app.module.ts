import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { NgxJsonViewerModule } from 'ngx-json-viewer';

import { RequestPanelComponent } from './components/request-panel-component/request.panel.component';
import { RequestProvider } from './providers/request.provider';

@NgModule({
  declarations: [
    RequestPanelComponent,
  ],
  imports: [
    BrowserModule,
    NgxJsonViewerModule
  ],
  providers: [
    RequestProvider
  ],
  bootstrap: [RequestPanelComponent]
})
export class AppModule { }
