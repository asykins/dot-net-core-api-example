import { Component, Input } from "@angular/core";

@Component({
    selector: "shared-loading-spinner",
    templateUrl: "./loading-spinner.component.html"
})
export class LoadingSpinnerComponent {
    @Input() loading: boolean;
    @Input() width: number;
    @Input() height: number;
 }