export interface CompanyAgent {
  cuit: string;
  offers: Offer[];
  id: string;
  userName: any;
  email: any;
  firstName: string;
  lastName: string;
}

export interface Offer {
  id: string;
  title: string;
  description: string;
  validUntil: Date;
}
