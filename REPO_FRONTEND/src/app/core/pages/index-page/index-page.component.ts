import { Component } from '@angular/core';
import { FooterComponent } from "../../../shared/components/footer/footer.component";
import { HeaderComponent } from '../../../shared/components/header/header.component';
import { IndexComponent } from '../../components/index/index.component';

@Component({
  selector: 'app-index-page',
  standalone: true,
  imports: [HeaderComponent,FooterComponent,IndexComponent],
  templateUrl: './index-page.component.html',
  styleUrl: './index-page.component.scss'
})
export class IndexPageComponent {

}
