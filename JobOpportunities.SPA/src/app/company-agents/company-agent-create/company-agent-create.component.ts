import { SuccessModalComponent } from './../../shared/modals/success-modal/success-modal.component';
import { DatePipe } from '@angular/common';
import { Router } from '@angular/router';
import { ErrorHandlerService } from './../../common/services/error-handler.service';
import { CompanyAgentsRepositoryService } from './../../common/services/company-agents-repository.service';
import { Component, OnInit } from '@angular/core';
import {
  AbstractControl,
  FormControl,
  FormGroup,
  Validators,
} from '@angular/forms';
import { HttpErrorResponse } from '@angular/common/http';
import { ModalOptions, BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { CompanyAgentForCreation } from 'src/app/common/models/company-agent-for-creation';
import { CompanyAgent } from 'src/app/common/models/company-agent';

@Component({
  selector: 'app-company-agent-create',
  templateUrl: './company-agent-create.component.html',
  styleUrls: ['./company-agent-create.component.scss'],
})
export class CompanyAgentCreateComponent implements OnInit {
  errorMessage: string = '';
  companyAgentForm: FormGroup;
  bsModalRef?: BsModalRef;
  constructor(
    private repository: CompanyAgentsRepositoryService,
    private errorHandler: ErrorHandlerService,
    private router: Router,
    private datePipe: DatePipe,
    private modal: BsModalService
  ) {}
  ngOnInit(): void {
    this.companyAgentForm = new FormGroup({
      firstName: new FormControl('', [
        Validators.required,
        Validators.maxLength(60),
      ]),
      lastName: new FormControl('', [
        Validators.required,
        Validators.maxLength(60),
      ]),
      cuit: new FormControl('', [Validators.required]),
      userName: new FormControl('', [Validators.required]),
      email: new FormControl('', [Validators.required, Validators.email]),
    });
  }

  validateControl = (controlName: string) => {
    let control: AbstractControl = this.companyAgentForm.get(controlName);
    if (control.invalid && control.touched) return true;
    return false;
  };

  hasError = (controlName: string, errorName: string) => {
    if (this.companyAgentForm.get(controlName).hasError(errorName)) return true;

    return false;
  };

  createCompanyAgent = (companyAgentFormValue) => {
    if (this.companyAgentForm.valid)
      this.executeCompanyAgentCreation(companyAgentFormValue);
  };

  redirectToOwnerList() {}

  private executeCompanyAgentCreation = (companyAgentFormValue) => {
    const companyAgent: CompanyAgentForCreation = {
      firstName: companyAgentFormValue.firstName,
      lastName: companyAgentFormValue.lastName,
      cuit: companyAgentFormValue.cuit,
      email: companyAgentFormValue.email,
      userName: companyAgentFormValue.userName,
    };
    const apiUrl = 'CompanyAgent';
    this.repository.createCompanyAgent(apiUrl, companyAgent).subscribe({
      next: (comp: CompanyAgent) => {
        const config: ModalOptions = {
          initialState: {
            modalHeaderText: 'Success Message',
            modalBodyText: `Owner: ${comp.userName} created successfully`,
            okButtonText: 'OK',
          },
        };
        this.bsModalRef = this.modal.show(SuccessModalComponent, config);
        this.bsModalRef.content.redirectOnOk.subscribe((_) =>
          this.redirectToOwnerList()
        );
      },
      error: (err: HttpErrorResponse) => {
        this.errorHandler.handleError(err);
        this.errorMessage = this.errorHandler.errorMessage;
      },
    });
  };
}
