import { Component } from "@angular/core";

@Component({
    selector: "shared-loading-spinner",
    templateUrl: "./loading-spinner.component.html",
    inputs: ["loading", "height", "width"]
})
export class LoadingSpinnerComponent {
    loading: boolean;
    width: number;
    heigth: number;
 }