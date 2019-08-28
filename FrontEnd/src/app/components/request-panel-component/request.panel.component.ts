import { Component } from '@angular/core';
import { RequestProvider } from 'src/app/providers/request.provider';

@Component({
    selector: 'app-root',
    templateUrl: 'request.panel.component.html'
})
export class RequestPanelComponent {
    requestStatusCode: number = 400;
    title = 'frontend';
    responseData = undefined;
    constructor(
        private requestProvider: RequestProvider) {

    }

    requestJwtToken() {
        this.requestProvider.requestJwtToken().subscribe();
    }
}
