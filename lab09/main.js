let probChart = null;

document.getElementById('btnSimulate').addEventListener('click', runSimulation);
document.getElementById('btnReset').addEventListener('click', resetSimulation);

function expRandom(rate) {
    if (rate <= 0) return Infinity;
    return -Math.log(1 - Math.random()) / rate;
}

function runSimulation() {
    const lambda = parseFloat(document.getElementById('lambda').value);
    let mu_orig = parseFloat(document.getElementById('mu').value);
    let mu = mu_orig;
    const T = parseFloat(document.getElementById('simDuration').value);
    const failRate = parseFloat(document.getElementById('failRate').value);
    const repairRate = parseFloat(document.getElementById('repairRate').value);

    if (lambda <= 0 || mu <= 0 || T <= 0 || failRate < 0 || repairRate <= 0) {
        alert("Параметры должны быть больше нуля (интенсивность поломок может быть 0).");
        return;
    }

    let time = 0;
    
    // 0 = простой, 1 = в работе, 2 = поломан
    let state = 0;
    
    let timeInState = [0, 0, 0];
    let lastTime = 0;

    let arrivals = 0;
    let served = 0;
    let rejected = 0;

    let nextArrival = expRandom(lambda);
    let nextDeparture = Infinity;
    let nextFailure = expRandom(failRate);
    let nextRepair = Infinity;

    // Главный цикл событий
    while (time <= T) {
        const nextEventTime = Math.min(nextArrival, nextDeparture, nextFailure, nextRepair);
        
        if (nextEventTime > T) {
            // Завершение симуляции
            timeInState[state] += (T - lastTime);
            break;
        }

        // Учет времени в состоянии
        timeInState[state] += (nextEventTime - lastTime);
        lastTime = nextEventTime;
        time = nextEventTime;

        if (nextEventTime === nextFailure) {
            // Поломка
            if (state === 1) {
                // Если обслуживали заявку, она отменяется (отказ)
                served--;
                rejected++;
            }
            state = 2; // Поломан
            nextDeparture = Infinity;
            nextFailure = Infinity;
            nextRepair = time + expRandom(repairRate);
        } else if (nextEventTime === nextRepair) {
            // Починка
            state = 0; // Возврат в простой
            nextRepair = Infinity;
            nextFailure = time + expRandom(failRate);
        } else if (nextEventTime === nextArrival) {
            // Пришла заявка
            arrivals++;
            if (state === 0) {
                state = 1;
                served++;
                
                nextDeparture = time + expRandom(mu);
            } else {
                // Отказ, если занят или поломан
                rejected++;
            }
            nextArrival = time + expRandom(lambda);
        } else {
            // Окончание обслуживания
            state = 0;
            nextDeparture = Infinity;
        }
    }

    // Эмпирические данные
    const empP0 = timeInState[0] / T;
    const empP1 = timeInState[1] / T;
    const empP2 = timeInState[2] / T;
    const empRejectionRate = arrivals > 0 ? rejected / arrivals : 0;

    document.getElementById('empIdle').textContent = empP0.toFixed(4);
    document.getElementById('empRejection').textContent = empRejectionRate.toFixed(4);
    document.getElementById('empBusy').textContent = empP1.toFixed(4);
    document.getElementById('empBroken').textContent = empP2.toFixed(4);
}

function resetSimulation() {
    document.getElementById('lambda').value = 3;
    document.getElementById('mu').value = 4;
    document.getElementById('simDuration').value = 100;
    if (document.getElementById('failRate')) document.getElementById('failRate').value = 0.5;
    if (document.getElementById('repairRate')) document.getElementById('repairRate').value = 2;

    ['empIdle', 'empRejection', 'empBusy', 'empBroken'].forEach(id => {
        if (document.getElementById(id)) {
            document.getElementById(id).textContent = '-';
        }
    });
}

