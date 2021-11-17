import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ClientService } from 'src/app/core/services/client.service';
import { Client } from 'src/app/shared/models/client';

@Component({
  selector: 'app-client-detail',
  templateUrl: './client-detail.component.html',
  styleUrls: ['./client-detail.component.css']
})
export class ClientDetailComponent implements OnInit {

  client:Client | undefined;
  id: number =-1;



  constructor(private clientService : ClientService,
    private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.route.paramMap.subscribe(
      params => {
        this.id = Number(params?.get('id'));
        this.getClientDetail();
      }
    );
  }
  private getClientDetail() {
    this.clientService.getClientDetailById(this.id)
      .subscribe(c => {
        this.client = c;
      });

    }
}
