import { ClientService } from '../../core/services/client.service';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Client } from 'src/app/shared/models/client';

@Component({
  selector: 'app-client-list',
  templateUrl: './client-list.component.html',
  styleUrls: ['./client-list.component.css']
})
export class ClientListComponent implements OnInit {

  clients:Client[]=[];
  clientId: number = -1;

  constructor(private clientService:ClientService,
    private route:ActivatedRoute) { }

  ngOnInit() {
    this.route.paramMap.subscribe(params => {
      this.clientService.getAllClients()
        .subscribe(c => {
          this.clients = c;
        });
    }
  );
  }

}
