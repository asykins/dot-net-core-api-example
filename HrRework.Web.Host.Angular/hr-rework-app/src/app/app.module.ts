import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { AppComponent } from './app.component';
import { CandidateRepositoy } from './candidate/candidate-repository';
import { CoreModule } from './core/core.module';
import { HomeModule } from './home/home.module';
import { RouteModule } from './route/route.module';
import { SharedModule } from './shared/shared.module';


@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    SharedModule,
    CoreModule,
    RouteModule,
    HomeModule
  ],
  providers: [CandidateRepositoy],
  bootstrap: [AppComponent]
})
export class AppModule { }
