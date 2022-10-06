import { JobOffer } from './job-offer';

export interface CompanyAgent {
  cuit: string;
  offers: JobOffer[];
  id: string;
  userName: any;
  email: any;
  firstName: string;
  lastName: string;
}
