import { ProgramModule_mkProgram, ProgramModule_run } from "./.fable/Fable.Elmish.3.1.0/program.fs.js";
import { Program_withReactBatched } from "./.fable/Fable.Elmish.React.3.0.1/react.fs.js";
import { update, init } from "./State.js";
import { view } from "./View.js";

ProgramModule_run(Program_withReactBatched("elmish-app", ProgramModule_mkProgram(init, update, view)));

