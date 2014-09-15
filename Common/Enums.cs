using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace CornTracker
{
    public enum ENodeType
    {
        [Tag("Папка")]       FOLDER,
        [Tag("Задача")]      TASK,
        [Tag("Мета-задача")] METATASK,
        [Tag("#")]           COUNT
    }

    public enum ENodeStatus
    {
        [Tag("Назначена")]   ACTIVE,
        [Tag("На проверку")] COMPLETED,
        [Tag("Проверена")]   CHECKED,
        [Tag("Закрыта")]     CLOSED,
        [Tag("#")]           COUNT
    }

    public enum ENodeProcessStatus
    {
        [Tag("Выполняется")] ACTIVE,
        [Tag("Проверяется")] COMPLETED,
        [Tag("#")]           COUNT
    }

    public enum ECheckerType
    {
        [Tag("Автопроверка")]              AUTO,
        [Tag("Ответственный за родителя")] PARENT,
        [Tag("Личность")]                  PERSON,
        [Tag("#")]                         COUNT
    }

    public enum EAction
    {
        [Tag("")]          NONE,
        [Tag("Выполнить")] DONE,
        [Tag("Проверить")] CHECK,
        [Tag("#")]         COUNT
    }

    public enum ETaskAction
    {
        [Tag("Создал")]                CREATE,
        [Tag("Сменил статус")]         CHANGE_STATE,
        [Tag("Сменил ответственного")] CHANGE_RESPONSIBLE,
        [Tag("Сменил проверяющего")]   CHANGE_CHECKER,
        [Tag("Сменил родителя")]       CHANGE_PARENT,
        [Tag("#")]                     COUNT
    }
}
