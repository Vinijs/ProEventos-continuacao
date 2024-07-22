import { Evento } from "./Evento";
import { UserUpdate } from "./identity/UserUpdate";
import { RedeSocial } from "./RedeSocial";

export interface Palestrante {
  id: number;
  minicurriculo: string;
  user: UserUpdate;
  redesSociais: RedeSocial[];
  palestrantesEventos: Evento[];
}
