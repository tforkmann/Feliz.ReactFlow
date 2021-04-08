import { Msg, Model, ModelModule_init } from "./Domain.js";
import { Cmd_OfAsync_start, Cmd_OfAsyncWith_perform, Cmd_none } from "./.fable/Fable.Elmish.3.1.0/cmd.fs.js";
import { singleton } from "./.fable/fable-library.3.1.2/AsyncBuilder.js";
import { sleep } from "./.fable/fable-library.3.1.2/Async.js";

export function init() {
    return [ModelModule_init, Cmd_none()];
}

function delay(msg) {
    return singleton.Delay(() => singleton.Bind(sleep(2000), () => singleton.Return(msg)));
}

export function update(msg, currentModel) {
    switch (msg.tag) {
        case 2: {
            return [currentModel, Cmd_none()];
        }
        case 1: {
            return [new Model(currentModel.CurrentPage, currentModel.ShowQuickView, !currentModel.ShowLoader), (!currentModel.ShowLoader) ? Cmd_OfAsyncWith_perform((x_1) => {
                Cmd_OfAsync_start(x_1);
            }, delay, new Msg(1), (x) => x) : Cmd_none()];
        }
        default: {
            return [new Model(msg.fields[0], currentModel.ShowQuickView, currentModel.ShowLoader), Cmd_none()];
        }
    }
}

