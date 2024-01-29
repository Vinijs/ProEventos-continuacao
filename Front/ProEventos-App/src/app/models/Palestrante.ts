import { Evento } from "./Evento";
import { RedeSocial } from "./RedeSocial";

export interface Palestrante {
  id: number;
  nome: string;
  minicurriculo: string;
  imagemurl: string;
  telefone: string;
  email: string;
  redessociais: RedeSocial[];
  palestranteseventos: Evento[];
}
